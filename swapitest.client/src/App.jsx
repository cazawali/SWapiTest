import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [searchs, setSearchs] = useState();

    useEffect(() => {
        populateSearchData();
    }, []);

    /*if (searchs!== undefined && searchs.films !== undefined) {
        const listFilms = searchs.films.map((film) =>
            <li>{film}</li>
        );
    }*/
    const contents = searchs === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Films</th>
                    <th>Vehicles</th>
                </tr>
            </thead>
            <tbody>
                {searchs.map(search =>
                    <tr key={search.date}>
                        <td>{search.name}</td>
                        <td>{search.films}</td>
                        <td>{search.vehicles}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <form method="get" onSubmit={handleSubmit}>
            <label> Search StarWars Person</label>
            <input id="searchname" name="searchname" type="text" />
            <input type="submit" vallue="Search" />
        <div>
            <h1 id="tableLabel">Search Star Results</h1>
            <p>The Star Wars Search Component.</p>
            {contents}
            </div>
        </form>
    );

    
    
    async function populateSearchData() {

        const response = await fetch('searchstar');
        const data = await response.json();
        setSearchs(data);
 
    }

    function handleSubmit(e) {
        e.preventDefault();

        // Read the form data
       
        const srcname = e.target[0].value

        const encodedSearch = encodeURIComponent(srcname)
        
        const response = fetch('https://localhost:7046/searchstar?searchname=' + encodedSearch);
        data = response.json();
        setSearchs(data);
        /*useState();
        this.setState({ value: this.element.value });*/
    }
}

export default App;