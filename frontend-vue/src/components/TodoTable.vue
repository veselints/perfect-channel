<template>
  <table>
    <tr v-for="todo in todos" :key="todo.id">
      <td>{{todo.id}}</td>
      <td>{{todo.description}}</td>
      <td>{{todo.completed}}</td>
    </tr>
  </table>
</template>

<script>

export default {
  name: 'TodoTable',
  props: ['todos']
}
</script>

<style scoped>

</style>
