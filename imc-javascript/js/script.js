//! Lista Global
const listaPessoas = [];


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
    const sitTXT = geraSituacao(imc);



    const pessoa =
    {
        nome,
        altura,
        peso,
        imc,
        situacao: sitTXT
    }

    listaPessoas.push(pessoa);

    //! Exibe a tabela
    exibirDados();

    //! Limpa dados do formulario
    limpaForm();
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

function exibirDados() {
    console.log(listaPessoas);

    let linhas = "";

    listaPessoas.forEach(function (objPess) {
        //! linhas de tabela no HTML
        linhas += `
            <tr>
                <td>${objPess.nome}</td>
                <td>${objPess.altura}</td>
                <td>${objPess.peso}</td>
                <td>${objPess.imc}</td>
                <td>${objPess.situacao}</td>
            </tr>
        `;
    })

    document.getElementById("cadastro").innerHTML = linhas;
}

function limpaForm () {
    document.getElementById("nome").value = "";
    document.getElementById("altura").value = "";
    document.getElementById("peso").value = "";
}