import './App.css';
import Titulo from './components/Titulo/Titulo';
import Card from './components/Card-Evento/Card-Evento.js'

function App() {
  return (
    <div className="App">
      <h1>Hello React</h1>
      <Titulo texto="Matheus"/>
      <br></br>

      <Card 
            titulo="Linguagem C#" 
            texto="Venha descobrir diversas curiosidades e novas atualizações sobre a linguagem C#"
            textoLink="Vamos surfar"
            disabled={true}
      />

      <Card 
            titulo="SPA" 
            texto="Venha descobrir o que são as SPA(Single Page Application)"
            textoLink="Começar"
            disabled={true}
      />
      <Card 
            titulo="Pokemon Hunter" 
            texto="Vamos caçar todos os pokemons que existem"
            textoLink="Vamos pegar"
            disabled={false}
      />
    </div>
  );
}

export default App;
