document.addEventListener('DOMContentLoaded', () => {
    fetch('http://localhost:5000/api/evento')
        .then(response => response.json())
        .then(data => {
            const eventosList = document.getElementById('eventosList');
            eventosList.innerHTML = data.map(evento => `
                <tr>
                    <td>${evento.Titulo}</td>
                    <td>${evento.Descripcion}</td>
                    <td>${evento.Lugar}</td>
                    <td>${new Date(evento.Fecha).toLocaleDateString()}</td>
                    <td>
                        <button class="btn btn-primary btn-sm">Editar</button>
                        <button class="btn btn-danger btn-sm">Eliminar</button>
                    </td>
                </tr>
            `).join('');
        })
        .catch(error => console.error('Error al cargar los eventos:', error));
});