const uri = 'api/Genres';
let genres = [];

function getGenres() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayGenres(data))
        .catch(error => console.error("Жанри не знайдені", error));
}

function addGenre() {
    const addNameTextbox = document.getElementById('add-name');

    const genre = {
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(genre)
    })
        .then(response => response.json())
        .then(() => {
            getGenres();
            addNameTextBox.value = '';
        })
        .catch(error => console.error('Не вдалося додати жанр', error));
    document.getElementById('add-name').value = '';
}

function deleteGenre(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getGenres())
        .catch(error => console.error('Не вдалося видалити жанр'), error);
}

function displayEditForm(id) {
    const genre = genres.find(genre => genre.id === id);

    document.getElementById('edit-id').value = genre.id;
    document.getElementById('edit-name').value = genre.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateGenre() {
    const genreId = document.getElementById('edit-id').value;
    const genre = {
        id: parseInt(genreId, 10),
        name: document.getElementById('edit-name').value.trim()
    }

    fetch(`${uri}/${genreId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(genre)
    })
        .then(() => getGenres())
        .catch(error => console.error('Не вдалось оновити жанр', error));

    closeInput();
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = none;
}

function _displayGenres(data) {
    const tBody = document.getElementById('genres');
    tBody.innerHTML = '';

    const button = document.createElement('button');
    
    data.forEach(genre => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('onclick', `displayEditForm(${genre.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deleteGenre(${genre.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(genre.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    genres = data;
}


