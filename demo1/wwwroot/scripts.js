//http://www.davejennifer.com/computerjunk/javascript/tail-dash-f.html


function swap32(val) {
	return ((val & 0xFF) << 24)
		| ((val & 0xFF00) << 8)
		| ((val >> 8) & 0xFF00)
		| ((val >> 24) & 0xFF);
}




function load(filename, from, to, callback)
{
	var meter = document.getElementById('value1');
	console.log("Loading file: " + filename);
	var xhr = new XMLHttpRequest();
	xhr.responseType = "arraybuffer";
	//xhr.overrideMimeType("application/octet-stream");
	xhr.open("GET", filename, true);
	xhr.setRequestHeader('Range', 'bytes=' + from + '-' + to);
	xhr.onprogress = (event) => {
		meter.value = (100 * event.total / event.loaded);
		console.log("Downloaded ${event.loaded} of ${event.total} bytes");
	}
	xhr.onload = function (e) {
		var buffer = xhr.response;
		var f = new Float32Array(buffer, 0, buffer.byteLength / 4);
		var n = f.length / 4;
		var x = new Float32Array(n);
		var y = new Float32Array(n);
		var z = new Float32Array(n);
		for (var i = 0; i < n; i++) {
			x[i] = (f[i * 4 + 0]);
			y[i] = (f[i * 4 + 1]);
			z[i] = (f[i * 4 + 2]);
		}
		console.log(f);
		console.log(x);
		console.log(y);
		console.log(z);
		callback(x, y, z);
	};
	xhr.onerror = function (e)
	{
		console.error(e);
	};
	xhr.send();
}









function load_layout(filename, callback)
{
	console.log("Loading file: " + filename);
	var xhr = new XMLHttpRequest();
	xhr.open("GET", filename, true);
	xhr.onload = function (e)
	{
		//console.log(xhr.responseText);
		var obj = JSON.parse(xhr.responseText);
		//console.log(obj);
		callback(obj);
	};
	xhr.onerror = function (e)
	{
		console.error(e);
	};
	xhr.send();
}









