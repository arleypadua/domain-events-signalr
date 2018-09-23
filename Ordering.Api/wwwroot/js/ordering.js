﻿const eventList = document.getElementById("event-list");
const connection = new signalR.HubConnectionBuilder().withUrl("/ordering-events").build();

document.getElementById("placeOrder").addEventListener("click", (event) => {
    var order = {
        customerName: "Maria",
        orderLines: [
            { productName: "Blue Cap", quantity: 1 },
            { productName: "Black Shirt", quantity: 3 }
        ]
    };

    postOrder(order);

    addEventToList("Place order requested. Waiting server response...");
});

connection.on("orderPlaced", function (orderResult) {
    addEventToList(`Order with id ${orderResult.orderId} placed.`);
});

connection.start().catch(err => console.error(err.toString()));

const postOrder = order => {
    var request = new XMLHttpRequest();
    request.onreadystatechange = () => {
        if (request.readyState === 4) {
            if (request.status !== 200) {
                addEventToList("Error on placing order.");
            }
        }
    };
    
    request.open("POST", "/api/orders");

    request.setRequestHeader("Content-Type", "application/json");

    request.send(JSON.stringify(order));
};

const addEventToList = text => {
    let li = document.createElement("li");
    li.innerText = text;

    eventList.appendChild(li);
};