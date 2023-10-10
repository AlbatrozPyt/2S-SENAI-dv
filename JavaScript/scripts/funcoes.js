        function calcular() {
            event.preventDefault();

            let n1 = parseFloat(document.getElementById("numero1").value);
            let n2 = parseFloat(document.getElementById("numero2").value);
            let res;
            let op = document.getElementById("operacao").value;

            if (isNaN(n1) || isNaN(n2))
            {   
                return alert("Preencha todos os campos");
            }

            if (op == '+') {
                res = somar(n1, n2);
            }
            else if (op == '-') {
                res = subtrair(n1, n2);
            }
            else if (op == '/') {
                res = dividir(n1, n2);
            }
            else if (op == '*') {
                res = multiplicar(n1, n2);
            }
            else {
                res = "Selecione uma operação!!!";
            }

            console.log(`Resultado: ${res}`);
            document.getElementById("resultado").innerText = res;
            // alert(`Resutado da soma: ${res}`)

        }

        function somar(x, y) {
            return (x + y).toFixed(2);
        }

        function subtrair(x, y) {
            return (x - y).toFixed(2);
        }

        function dividir(x, y) {
            if (y == 0) {
                return "Não é possivel dividir por 0 !!!"
            }
            return (x / y).toFixed(2);
        }

        function multiplicar(x, y) {
            return (x * y).toFixed(2);
        }
