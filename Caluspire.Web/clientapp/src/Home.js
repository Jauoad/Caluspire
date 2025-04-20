import React, { useState, useEffect } from 'react';

function Home() {
    const [message, setMessage] = useState('');

    useEffect(() => {
        // Appel à l'API backend (ex: https://localhost:7010/api/home) pour récupérer un message
        fetch('https://localhost:7010/api/home')
            .then(response => response.json())
            .then(data => setMessage(data.message))
            .catch(error => console.error('Erreur:', error));
    }, []);

    return (
        <div>
            <h1>Welcome to Caluspire</h1>
            <p>{message}</p>
        </div>
    );
}

export default Home;