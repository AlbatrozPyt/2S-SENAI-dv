/**
 * Funcao que inverte a data do banco de dados
 * @param {*} data 
 * @returns 
 */

export const dateFormatDbToView = (data) => {
    console.log(data);
    //! EX: 2023-12-28T00:00:00 para 28/12/2023
    //data = "2023-12-28T00:00:00"
    data = data.substr(0, 10) // Retorna a data 2023-12-28
    data = data.split("-"); // Retorna a data [2023, 12, 28]
    return `${data[2]}/${data[1]}/${data[0]}`; // 28/12/2023
}

