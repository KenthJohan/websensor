//http://www.davejennifer.com/computerjunk/javascript/tail-dash-f.html


function swap32(val)
{
	return ((val & 0xFF) << 24)
		| ((val & 0xFF00) << 8)
		| ((val >> 8) & 0xFF00)
		| ((val >> 24) & 0xFF);
}




function req_arraybuffer(filename, from, to, callback)
{
	var meter = document.getElementById('value1');
	console.log("Loading file: " + filename);
	var xhr = new XMLHttpRequest();
	xhr.responseType = "arraybuffer";
	//xhr.overrideMimeType("application/octet-stream");
	xhr.open("GET", filename, true);
	xhr.setRequestHeader('Range', 'bytes=' + from + '-' + to);
	xhr.onprogress = (event) =>
	{
		meter.value = (100 * event.total / event.loaded);
		console.log("Downloaded ${event.loaded} of ${event.total} bytes");
	}
	xhr.onload = function (e)
	{
		var buffer = xhr.response;
		var f = new Float32Array(buffer, 0, buffer.byteLength / 4);
		var n = f.length / 4;
		var x = new Float32Array(n);
		var y = new Float32Array(n);
		var z = new Float32Array(n);
		for (var i = 0; i < n; i++)
		{
			x[i] = (f[i * 4 + 0]);
			y[i] = (f[i * 4 + 1]);
			z[i] = (f[i * 4 + 2]);
			//w[i] = (f[i * 4 + 3]);Light intensity
		}
		//console.log(f);
		//console.log(x);
		//console.log(y);
		//console.log(z);
		callback(x, y, z);
	};
	xhr.onerror = function (e)
	{
		console.error(e);
	};
	xhr.send();
}









function req_json(filename, callback)
{
	console.log("Requesting json from: " + filename);
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









var quantity1dims = ["humidity", "temperature"];


var converters = {};
converters["timestamp"] = function(view)
{
	var r;
	r = view.getFloat64(0, true);
	return r;
}
converters["position_gcs"] = function(view)
{
	var r = [];
	r[0] = view.getFloat32(0, true);
	r[1] = view.getFloat32(4, true);
	return r;
}
converters["temperature"] = function(view)
{
	var r;
	r = view.getFloat32(0, true);
	return r;
}
converters["humidity"] = function(view)
{
	var r;
	r = view.getFloat32(0, true);
	return r;
}
converters["position_xyzw"] = function(view)
{
	var r = [];
	r[0] = view.getFloat32(0, true);
	r[1] = view.getFloat32(4, true);
	r[2] = view.getFloat32(8, true);
	r[3] = view.getFloat32(12, true);
	return r;
}

var colors = 
{
	"timestamp":"rgb(150, 160, 221)",
	"position_xyzw":"rgb(212, 150, 202)",
	"position_gcs":"rgb(143, 211, 169)",
	"temperature":"rgb(255, 151, 151)",
	"humidity":"rgb(174, 252, 255)"
};
