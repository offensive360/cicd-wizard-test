// Simple Node.js app for SAST testing
const express = require('express');
const app = express();

app.get('/user', (req, res) => {
  const id = req.query.id;
  // XSS vulnerability (intentional for SAST test)
  res.send('<div>User: ' + id + '</div>');
});

app.get('/exec', (req, res) => {
  const { exec } = require('child_process');
  const cmd = req.query.cmd;
  // Command injection (intentional for SAST test)
  exec(cmd, (err, stdout) => {
    res.send(stdout);
  });
});

app.listen(3000);
