@echo off
rmdir /S /Q node_modules
rmdir /S /Q node-website
call npm install
echo(
echo Use this to run : node index.js
@echo on