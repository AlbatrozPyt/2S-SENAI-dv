const somar = function name(x, y) {
    return x + y;
}

//* 1a Forma
// const dobro = (x) => {
//     return x*2;
// }


//* 2a Forma
// const dobro = x => {
//     return x*2;
// }

//* 3a Forma
//const dobro = x => x*2;

// const boaTarde = () => console.log("Boa Tarde !!!");

// console.log(dobro(7));
// console.log(somar(3, 4));
// boaTarde()

const convidados = [
    {nome:"Gabriel", idade:17},
    {nome:"Heitor", idade:17},
    {nome:"Barak Obama", idade:67},
    {nome:"Cristiano Ronaldo", idade:40},
    
]

console.log();
console.log(`Pessoas convidadas:`);
convidados.forEach(item => {
    console.log(`   Convidado: ${item.nome}, ${item.idade} anos`);
})

console.log();
