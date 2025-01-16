function openNewPage() {
    // Llama a la página a la que quieres redirigir
    window.location.href = 'Login.aspx';
}

// Agregar un nuevo campo de entrada para enlaces
function addLinkInput() {
    var contador = 0;
    const container = document.getElementById("linkContainer");
    //Inhabilirar el campo anterior
    const elementos = container.getElementsByClassName("form-control")
    contador = elementos.length - 1;

    if (contador < 4) {
        elementos.item(contador).disabled = true;
        //Agregar campo nuevo
        const newInput = document.createElement("input");
        newInput.type = "text";
        newInput.className = "form-control link-input";
        newInput.name = "links[]";
        newInput.placeholder = contador.toString();
        container.appendChild(newInput);
    } else {
        alert("Solo puede agragar maximo 5 enlaces.");
    }

}

function removeLinkInput() {
    var contador = 0;
    const container = document.getElementById("linkContainer");
    const inputs = container.getElementsByClassName("form-control");
    //Inhabilirar el campo anterior
    const elementos = container.getElementsByClassName("form-control")
    contador = elementos.length - 2;
    if (contador >= 0) {
        elementos.item(contador).disabled = false;
        const lastInput = inputs[inputs.length - 1];
        container.removeChild(lastInput);
    }

    //Agregar campo nuevo
}