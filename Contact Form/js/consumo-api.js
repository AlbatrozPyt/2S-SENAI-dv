
const urlLocal = "http://localhost:3000/contatos";

async function cadastrar(e) {
    e.preventDefault();

    const nome = document.getElementById("nome").value;
    const sobrenome = document.getElementById("sobrenome").value;
    const email = document.getElementById("email").value;
    const pais = document.getElementById("pais").value;
    const ddd = document.getElementById("ddd").value;
    const telefone = document.getElementById("telefone").value;
    const cep = document.getElementById("cep").value;
    const endereco = document.getElementById("rua").value;
    const numero = document.getElementById("numero").value;
    const complemento = document.getElementById("complemento").value;
    const bairro = document.getElementById("bairro").value;
    const cidade = document.getElementById("cidade").value;
    const estado = document.getElementById("UF").value;

    const objDados = { cep, endereco, bairro, cidade, estado, nome, telefone, numero, sobrenome, email, pais, ddd, complemento };

    try {
        const promise = await fetch(urlLocal, {
            body: JSON.stringify(objDados), // Transforma objeto em JSON
            headers: { "Content-Type": "application/json" },
            method: "post"
        })
    } catch (error) {
        alert(`Deu ruim: ${error}`)
    }
}

async function chamarApi() {
    const cep = document.getElementById("cep").value;
    const url = `https://viacep.com.br/ws/${cep}/json/`;

    // resolvida ou fullfield
    try {
        const promise = await fetch(url);
        const endereco = await promise.json();

        exibirEndereco(endereco);
        document.getElementById("not-found").innerText = "";

    }
    // rejeitada
    catch (error) {
        limparEndereco();
        document.getElementById("not-found").innerText = "CEP invalido";
    }
}

function exibirEndereco(endereco) {
    document.getElementById("rua").value = endereco.logradouro;
    document.getElementById("bairro").value = endereco.bairro;
    document.getElementById("cidade").value = endereco.localidade;
    document.getElementById("UF").value = endereco.uf;
}

function limparEndereco() {
    document.getElementById("rua").value = "";
    document.getElementById("bairro").value = "";
    document.getElementById("cidade").value = "";
    document.getElementById("UF").value = "";
}

