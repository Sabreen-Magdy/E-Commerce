import { Component } from '@angular/core';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
})
export class TodoListComponent {
  todoList: string[] = [];

  value: string = '';
  AddToList() {
    this.todoList.push(this.value);
    this.value = '';
  }

  Remove(i: number) {
    // console.log(i);
    this.todoList = this.todoList.filter((item, index) => index != i);
  }
}
