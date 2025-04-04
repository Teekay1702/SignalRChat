let username = sessionStorage.getItem("username");

if (!username) {
    username = prompt("Enter your username:");
    sessionStorage.setItem("username", username);
}

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.start()
    .then(() => console.log("Connected to SignalR"))
    .catch(err => console.error("Error connecting:", err));

document.getElementById("messageInput").addEventListener("keypress", function (event) {
    if (event.key === "Enter") {
        sendMessage();
    }
});

function sendMessage() {
    const message = document.getElementById("messageInput").value;

    if (message) {
        connection.invoke("SendMessage", message)
            .catch(err => console.error(err.toString()));

        document.getElementById("messageInput").value = "";
    }
}

connection.on("ReceiveMessage", (user, message) => {
    const msg = document.createElement("li");
    msg.textContent = `${user}: ${message}`;
    document.getElementById("messagesList").appendChild(msg);
});
