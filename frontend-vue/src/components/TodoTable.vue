<template>
  <table>
    <tr>
      <th>ID</th>
      <th>Description</th>
      <th>Completed</th>
    </tr>
    <tr v-for="todo in todos" :key="todo.id">
      <td>{{todo.id}}</td>
      <td>{{todo.description}}</td>
      <td><input type="checkbox" :checked="todo.completed" @change="onChange($event,todo)"></td>
    </tr>
  </table>
</template>

<script>

export default {
  name: 'TodoTable',
  props: ['todos'],
  methods: {
    onChange (e, todo) {
      const model = {
        id: todo.id,
        description: todo.description,
        completed: e.target.checked
      }

      this.$store.dispatch('updateTodo', model)
    }
  }
}
</script>

<style scoped>
  table, th, td {
    border: 1px solid gray;
  }
</style>
