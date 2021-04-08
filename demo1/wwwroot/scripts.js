

function swap32(val) {
    return ((val & 0xFF) << 24)
           | ((val & 0xFF00) << 8)
           | ((val >> 8) & 0xFF00)
           | ((val >> 24) & 0xFF);
}




function load(filename, from, to, callback)
{
	var meter = document.getElementById('value1');
	//var filename = "/test.txt";
	//var filename = "/data/miloatv/temperature";
	//var filename = "/data/miloatv/p2.out";
	//var filename = "/data/./Program.cs";
	console.log("Loading file: " + filename);
	var xhr = new XMLHttpRequest();
	xhr.responseType = "arraybuffer";
	//xhr.overrideMimeType("application/octet-stream");
	xhr.open("GET", filename, true);
	xhr.setRequestHeader('Range', 'bytes='+from+'-'+to);
	//xhr.responseType = "arraybuffer";

	xhr.onprogress = (event) => 
	{
		// event.loaded returns how many bytes are downloaded
		// event.total returns the total number of bytes
		// event.total is only available if server sends `Content-Length` header
		meter.value = (100 * event.total / event.loaded);
		console.log(`Downloaded ${event.loaded} of ${event.total} bytes`);
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
			x[i] = (f[i*4+0]);
			y[i] = (f[i*4+1]);
			z[i] = (f[i*4+2]);
		}
		//console.log(f);
		//console.log(x);
		//console.log(y);
		//console.log(z);
		callback(x,y,z);
	};

	xhr.onerror = function (e)
	{
		//console.log(e);
	};
	xhr.send();
}




function test()
{
	load('/data/miloatv/p2.out', 0, 102400, (x,y,z) => {
		console.log(x);
		var trace1 = 
		{
			x:x, y:y, z:z,
			mode: 'markers',
			marker:
			{
				size: 1,
				opacity: 1.0,
				symbol: 'square'
			},
			type: 'scatter3d'
		};
		console.log(trace1.x);

		var layout = {margin: {
			l: 0,
			r: 0,
			b: 0,
			t: 0
		}};
		Plotly.newPlot('myDiv', [trace1], layout);
	});
}


