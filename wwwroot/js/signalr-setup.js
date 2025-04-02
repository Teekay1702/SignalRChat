const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")  // Replace "/chatHub" with your actual hub URL if different
    .build();

connection.start()
    .then(() => console.log("Connected to SignalR"))
    .catch(err => console.error("Error connecting:", err));
