"""Simple Python web app for SAST testing."""
import sqlite3
import subprocess
from flask import Flask, request

app = Flask(__name__)



@app.route("/search")
def search():
    query = request.args.get("q", "")
    conn = sqlite3.connect("users.db")
    # SQL injection vulnerability (intentional for SAST test)
    result = conn.execute("SELECT * FROM users WHERE name = '" + query + "'")
    return str(list(result))

@app.route("/run")
def run_command():
    cmd = request.args.get("cmd", "ls")
    # Command injection vulnerability (intentional for SAST test)
    output = subprocess.check_output(cmd, shell=True)
    return output

if __name__ == "__main__":
    app.run(debug=True)
