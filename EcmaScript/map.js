const numeros = [1, 2, 5, 7, 10, 300, 555, 12000]
//console.log(numeros);

//! MAP
// const dobros = numeros.map((value) => {
//     return value*2
// });
// console.log(dobros);

//! FILTER
// const maior10 = numeros.filter((x) => {
//     return x >= 10;
// })
// console.log(maior10);

const comentarios = [
    {comentario: "bla bla bla", exibe: true},
    {comentario: "Evento lixo", exibe: false},
    {comentario: "Otimo evento !!!", exibe: true}
]

// const comentarioOk = comentarios.filter((c) => {
//     return c.exibe;
// })

// comentarioOk.forEach((item, index) => {
//     console.log(`   ${index+1}° Comentario - ${item.comentario}`);
// })

const soma = numeros.reduce((i, n) => {
    return n+i;
}, 0)
console.log(soma);