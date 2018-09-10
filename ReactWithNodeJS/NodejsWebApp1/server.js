//'use strict';
//var http = require('http');
//var port = process.env.PORT || 1337;

//http.createServer(function (req, res) {
//    res.writeHead(200, { 'Content-Type': 'text/plain' });
//    res.end('Hello World\n');
//}).listen(port);

'use strict';
var path = require('path');
var express = require('express');

var app = express();

var staticPath = path.join(__dirname, '/');
app.use(express.static(staticPath));

// Allows you to set port in the project properties.
app.set('port', process.env.PORT || 3000);

var server = app.listen(app.get('port'), function () {
    console.log('listening');
});


//P?edchoz� k�d pou��v� slu�bu Express k spu�t?n� aplikace Node.js jako serveru webov�ch aplikac�.
// Tento k�d nastav� port na ?�slo portu nakonfigurovan� v vlastnostech projektu (ve v�choz�m nastaven� je port nakonfigurov�n ve vlastnostech 1337).