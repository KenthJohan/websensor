var meter = document.getElementById('value1');

function test()
{
	//var filename = "/test.txt";
	//var filename = "/data/miloatv/temperature";
	var filename = "/data/miloatv/p2.out";
	//var filename = "/data/./Program.cs";
	console.log(filename);
	var xhr = new XMLHttpRequest();
	xhr.responseType = "arraybuffer";
	//xhr.overrideMimeType("application/octet-stream");
	xhr.open("GET", filename, true);
	xhr.setRequestHeader('Range', 'bytes=0-2000');
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
		var f = new Float32Array(buffer, 0, buffer.byteLength/4);
		console.log(f);
	};

	xhr.onerror = function (e)
	{
		//console.log(e);
	};
	xhr.send();
}







