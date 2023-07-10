const url = "http://localhost:5094/api/shirts"
const shirtsTable = document.querySelector('.shirts-table-content')
const shirtTableHeader = document.querySelector('.shirt-table-header')
const shirtTableContent = document.querySelector('.shirt-table-content')
const modalTitle = document.querySelector('.modal-title')

let modalName = "";
let modalTableHeader = `<td class="col-sm-6"> </td>`;
let modalTableContent = "";
let shirtsTableData = "";
let shirtData = "";

const renderShirts = (shirts) => {
	shirts.map((values)=>{
		shirtsTableData+= `			<tr data-id=${values.Id}>
		<td>${values.Id}</td>
		<td>${values.Name}</td>
		<td>${values.NumberOfColours}</td>
		<td>${values.NumberOfFabrics}</td>
		<td>${values.NumberOfImages}</td>
		<td><button type="button" id="edit-images" class="btn btn-secondary btn-sm" data-bs-toggle="modal" data-bs-target="#shirtModal">Edit Images</button></td>
	</tr>`;
	});

	shirtsTable.innerHTML = shirtsTableData;
}

const renderShirt = (shirt) => {
	modalName = `Item: ${shirt.Id} - Name: ${shirt.Name}`
	modalTitle.innerHTML = modalName;

	shirt.Colours.forEach(colour => {
		modalTableHeader += `<th scope="col">${colour.Name}</th>`
	});

	shirtTableHeader.innerHTML = modalTableHeader;

	shirt.Fabrics.forEach((fabric, index) => {
		let fabricId = shirt.Fabrics[index].Id;

		modalTableContent += `<tr>
		<th scope="col">${fabric.Type}</th>`

		shirt.Colours.forEach(colour => {
			modalTableContent += `<td>`
			
			shirt.Images.forEach(image => {
				if (image.FabricId == fabricId && image.ColourId == colour.Id) {
					console.log(image)
					modalTableContent += `<button> <img id="image" width="100" height="100" data-bs-toggle="tooltip" title="Click to remove" data-imageId="${image.id}" data-shirtId="${image.ShirtId}" src=${image.ImageUrl} /></button>`;
				}
			})
			
			modalTableContent += `<input type="file" id='file' hidden="hidden"><button data-shirtId="${shirt.Id}" data-fabricId="${fabricId}" data-colourId="${colour.Id}" type="button" id="add-image" class="btn btn-secondary btn-sm">Add</button></td>`
		})


		modalTableContent += `</tr>`
	});

	shirtTableContent.innerHTML = modalTableContent;
}

//GET - Get All Shirts
fetch(url)
	.then(res => res.json())
	.then(data => renderShirts(data));


shirtsTable.addEventListener(`click`, (e) => {
	e.preventDefault();

	let editBtnPressed = e.target.id == 'edit-images'

	if (editBtnPressed){
		let id = e.target.parentElement.parentElement.dataset.id;

		//GET - Single Shirt
		fetch(`${url}/${id}`)
			.then(res => res.json())
			.then(data => renderShirt(data))
	}
});

shirtTableContent.addEventListener(`click`, (e) => {
	e.preventDefault();

	let addBtnPressed = e.target.id == 'add-image'
	let imagePressed = e.target.id == 'image'

	if (addBtnPressed){
		let shirtId = e.target.dataset.shirtid;
		let colourId = e.target.dataset.colourid;
		let fabricId = e.target.dataset.fabricid;
		var input = document.createElement('input');
		input.type = 'file';

		input.onchange = e => { 
			var file = e.target.files[0]; 
			console.log(file)
			var data = new FormData()
			data.append('file', input.files[0])

			//POST - Create Image
			fetch(`${url}/${shirtId}/images?colourId=${colourId}&fabricId=${fabricId}`, {
				method: 'POST',
				body: data
			 })
				.then((response) => {
					if (response.status == 201) {
						alert("Image saved successfully!");
					} 
					else {
						alert("Something went wrong when trying to save your image!");
					}
				})
				.then(() => location.reload())
		}

		input.click();
	}

	if (imagePressed){
		let id = e.target.dataset.imageid;
		let shirtId = e.target.dataset.shirtid;
		if (confirm(`Remove image (Id: ${id} - T-Shirt: ${shirtId})? `)) {

			//DELETE - Image
			fetch(`${url}/${shirtId}/images/${id}`, {
				method: 'DELETE'
			})
				.then((response) => {
					if (response.status == 204) {
						alert("Image removed successfully!");
					} 
					else {
						alert("Something went wrong when trying to remove image!");
					}
				})
				.then(() => location.reload())
		}
	}
});