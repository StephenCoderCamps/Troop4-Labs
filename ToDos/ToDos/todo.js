var xhr = new XMLHttpRequest();
xhr.addEventListener('load', function (e) {
    var data = JSON.parse(xhr.responseText);
    var toDoList = '';
    data.forEach(function (todo) {
        toDoList += '<li>' + todo.TaskName + ' ' + todo.Description + ' ' + todo.IsCompleted
            + '</li>';
    });
    document.getElementById('mylist').innerHTML = toDoList;
});
xhr.open('GET', '/api/todos');
xhr.send();
var taskForm = document.getElementById('taskForm');
taskForm.addEventListener('submit', function (e) {
    e.preventDefault();
    var newTask = {
        taskName: document.getElementById('taskName').value,
        description: document.getElementById('description').value,
        isCompleted: document.getElementById('isCompleted').value
    };
    var xhr2 = new XMLHttpRequest();
    xhr2.open('POST', '/api/todos');
    xhr2.setRequestHeader('Accept', 'application/JSON');
    xhr2.setRequestHeader('Content-Type', 'application/JSON');
    xhr2.send(JSON.stringify(newTask));
});
//# sourceMappingURL=todo.js.map