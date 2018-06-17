var shapesCollection = null;
var elementIdx = 0;
var shapesRestoredFlag = false;

function getNewElementId(newElement) {
	let newIdx = elementIdx++;
	return newElement.id + "_" + newIdx.toString();
}

function reflectShapeToServer(elementParam, widthParam) {

	axios.post('/Shape/Reflect', {

		id: elementParam.id,
		type: $(elementParam).attr("data-shape-type"),
		width: widthParam,
		idx: elementIdx

	}).then(function (response) {
		if (response.status == 200) {
			$(elementParam).find("p")[0].innerText = response.data.area;
		}
		else {
			$(elementParam).find("p")[0].innerText = "";
			console.log("Error: " + response.status);
		}

	})

}

function attachShapeToNewParrent(event, ui, thisObject) {

	let targetShapeElement = $(event.target); 	// shpesSet
	let draggableSource = ui.helper[0];   // "squareShape"

	let targetElementId = targetShapeElement[0].id;
	let sourseElementId = draggableSource.parentElement.id;

	if (sourseElementId === targetElementId)
		return;

	let inputWidth = prompt("Enter the shape's primary dimension (width, radius, or base): ");

	// clone element
	let newElement = $(draggableSource).clone();

	$(newElement[0]).attr('id', getNewElementId(newElement[0]));
	reflectShapeToServer(newElement[0], inputWidth);
	newElement.appendTo(targetShapeElement).css({ position: 'relative', left: 0, top: 0 });
	realign(draggableSource);

	$(".draggableShape").draggable({
		stop: function (event, ui) {
			realign(this);
		}
	});

	applyDeletebleBehavior(newElement);

}

function realign(thisObject) {
	$(thisObject).css({ left: '0', top: '0' });
	return;
}

function applyDaraggapleDroppableBehavior() {
	$(".draggableShape").draggable({
		stop: function (event, ui) {
			realign(this);
		}
	});
	$("#shapesSet").droppable({
		drop: function (event, ui) {
			attachShapeToNewParrent(event, ui, this);
		}
	});
}

function applyDeletebleBehavior(deletableElement) {

	$(deletableElement).bind('contextmenu', function (e) {
		let thisId = this.id;
		if (this.parentElement.id == "shapesSet")
			$(this).detach();

		axios.post('/Shape/Remove', {
			id: thisId,
		});

		return false;
	});

}

function getSampleObjectId(shapeType) {
	switch (shapeType) {
		case "1":
			return "#squareShape";
			break;
		case "2":
			return "#circleShape";
			break;
		case "3":
			return "#triangleShape";
			break;
		default:
			break;
	}
}

function populateSelection(collectonString) {
	if (collectonString === null)
		return;

	let collectionJson = JSON.parse(collectonString);

	collectionJson.sort((a, b) => Number(a.Idx) - Number(b.Idx));
	elementIdx = 0;

	for (i = 0; i < collectionJson.length; i++) {
		let sampleObjectId = getSampleObjectId(collectionJson[i].ShapeType);
		let newElement = $(sampleObjectId).clone();

		$(newElement).attr('id', collectionJson[i].Id);
		newElement.appendTo("#shapesSet").css({ position: 'relative', left: '', top: '' });

		applyDeletebleBehavior(newElement);

		reflectShapeToServer(newElement[0], collectionJson[i].Width);
		elementIdx++;
	}
	applyDaraggapleDroppableBehavior();

}

function restoreSelectedShapes() {

	axios.get('/shape/LoadCollection', {})
		.then(function (response) {

			if (response.status == 200) {
				populateSelection(response.data.result);
				shapesRestoredFlag = true;
			}

		})

}


// document ready point
$(function () {

	if (!shapesRestoredFlag)
		restoreSelectedShapes();

	applyDaraggapleDroppableBehavior();

});