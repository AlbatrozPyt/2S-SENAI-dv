let Eduardo = {
    nome : "Eduardo",
    idade : 41,
    altura : 1.67
};

Eduardo.peso = 89;

let Carlos = new Object();
Carlos.nome = "Carlos";
Carlos.idade = 36;
Carlos.sobrenome = "Roque";

let pessoas = [];

pessoas.push(Eduardo);
pessoas.push(Carlos);

console.log(pessoas);

pessoas.forEach((x, index) => {
    console.log(`${index+1}º Pessoa - ${x.nome}`);
})