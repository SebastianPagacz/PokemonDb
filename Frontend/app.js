async function getData(){
    const url = "https://localhost:32771/api/Pokemon";

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
        let boxElem = document.createElement("span");
        let idElem = document.createElement("p");
        let nameElem = document.createElement("p");
        

        idElem.innerText = item.id;
        nameElem.innerText = item.name;

        dataContainer.appendChild(boxElem);
        boxElem.appendChild(idElem);
        boxElem.appendChild(nameElem);
    }
}

renderData();
