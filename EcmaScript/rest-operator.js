// const camisaLacoste = {
//     descricao: "Camisa Lacoste",
//     preco: 399.98,
//     marca: "Lacoste",
//     tamanho: "G",
//     cor: "Azul",
//     promo: true
// }

// const {descricao, preco, promo} = camisaLacoste;

// console.log(`
//     Produto: ${descricao}
//     Preço: ${preco}
//     Promo: ${promo ? "Sim" : "Não"}
// `);

const evento = {
    dataEvento : new Date(),
    descricaoEvento : "Festa de Haloween",
    presenca : true,
    exibe : true,
    comentario : "Festa muito legal e divertida!!!"
}

const {dataEvento, descricaoEvento, presenca, ...jujuba} = evento;

console.log();
console.log(dataEvento);
console.log(descricaoEvento);
console.log(presenca);
console.log(jujuba);