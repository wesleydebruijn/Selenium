angular.module('todoApp', [])
  .controller('TodoListController', function($scope, $http) {

    var todoList = this;
	todoList.naam = "Selenium test";
    todoList.todos = [
      {text:'Zimbabwe', done:true},
      {text:'Gambia', done:false}];
 
 
	$http.get("http://www.w3schools.com/angular/customers.php")
    .success(function(response) {$scope.names = response.records;
		for(var item in response.records){
			todoList.todos.push({text:response.records[item].Country, done:false});
		}
		
	});
 
    todoList.addTodo = function() {
      todoList.todos.push({text:todoList.todoText, done:false});
      todoList.todoText = '';
    };
 
    todoList.remaining = function() {
      var count = 0;
      angular.forEach(todoList.todos, function(todo) {
        count += todo.done ? 0 : 1;
      });
      return count;
    };
 
    todoList.archive = function() {
      var oldTodos = todoList.todos;
      todoList.todos = [];
      angular.forEach(oldTodos, function(todo) {
        if (!todo.done) todoList.todos.push(todo);
      });
    };
  });
  