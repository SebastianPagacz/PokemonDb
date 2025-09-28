async function getData(){
    const url = "https://localhost:8081/api/Pokemon";

    try{
        const response = await fetch(url,{
            method: "GET",
        });
        
        if (!response.ok){
            throw new Error("data not available");
        }

        const result = await response.json();
        console.log(result);
        
        return result;
    }
    catch(error){
        console.error(error.message);
    }
}

async function renderData(){
    let requestedData = await getData();
    const dataContainer = document.getElementById("container");
    
    for (const item of requestedData){
        let boxElem = document.createElement("div");
        let image = document.createElement("img");
        let idElem = document.createElement("p");
        let nameElem = document.createElement("p");
        
        const pokeImg = await fetch(`https://pokeapi.co/api/v2/pokemon/${item.id}/`,{
            method: "GET"
        });
        const imgData = await pokeImg.json();
        image.src = imgData.sprites.front_default;
        image.alt = item.name;

        image.className = "poke-image";

        idElem.innerText = item.id;
        nameElem.innerText = item.name;

        dataContainer.appendChild(boxElem);
        boxElem.appendChild(image);
        boxElem.appendChild(idElem);
        boxElem.appendChild(nameElem);
    }
}

renderData();
