function calcular(e) {
    e.preventDefault();

    let nome = document.getElementById("nome").value.trim();
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);


    if (isNaN(altura) || isNaN(peso) || nome.lenght < 2) {
        alert("É necessario preencher todos os campos !!!")
        return;
    }


    const imc = calcularImc(peso, altura).toFixed(2);
    const sit = geraSituacao(imc);

    // console.log(nome);
    // console.log(altura);
    // console.log(peso);
    // console.log(imc);
    // console.log(sit);

    const pessoa = 
    {
        nome : nome,
        altura : altura,
        peso : peso,
        imc : imc,
        sit : sit
    }

    console.log(pessoa);
}

function calcularImc(peso, altura) {
    return peso / (altura * altura);
}

function geraSituacao(imc) {
    if (imc <= 18.5) {
        return "Magreza Severa"
    }
    else if (imc <= 24.9) {
        return "Peso Normal"
    }
    else if (imc <= 29.9) {
        return "Acima do peso"
    }
    else if (imc <= 34.9) {
        return "Obesidade I"
    }
    else if (imc <= 39.99) {
        return "Obesidade II"
    }
    else {
        return "Cuidado !!!"
    }
}