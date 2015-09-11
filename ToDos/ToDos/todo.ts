interface ToDo {
    TaskName: string,
    Description: string,
    IsCompleted: boolean
}

let xhr = new XMLHttpRequest();
xhr.addEventListener('load', (e) => {
    let data = <ToDo[]>JSON.parse(xhr.responseText);
    let toDoList = '';
    data.forEach((todo) => {
        toDoList += '<li>' + todo.TaskName + ' ' + todo.Description + ' ' + todo.IsCompleted
        + '</li>';
    });
    document.getElementById('mylist').innerHTML = toDoList;
});


xhr.open('GET', '/api/todos');
xhr.send();

let taskForm = document.getElementById('taskForm');
taskForm.addEventListener('submit', (e) => {
    e.preventDefault();
    let newTask = {
        taskName: (<HTMLInputElement>document.getElementById('taskName')).value,
        description: (<HTMLInputElement>document.getElementById('description')).value,
        isCompleted: (<HTMLInputElement>document.getElementById('isCompleted')).value
    };
    let xhr2 = new XMLHttpRequest();
    xhr2.open('POST', '/api/todos');
    xhr2.setRequestHeader('Accept', 'application/JSON');
    xhr2.setRequestHeader('Content-Type', 'application/JSON');

    xhr2.send(JSON.stringify(newTask));
});
