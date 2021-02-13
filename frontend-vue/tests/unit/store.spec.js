import { expect } from 'chai'
import { getters, mutations } from '@/store/index.js'

const { pendingTodos, doneTodos } = getters
const { remoteError, populateTodos } = mutations

describe('test store', () => {
  it('getters return data', () => {
    const state = {
      todos: [
        { id: 1, description: 'First', completed: true },
        { id: 2, description: 'Second', completed: true },
        { id: 3, description: 'Third', completed: true },
        { id: 4, description: 'Forth', completed: false },
        { id: 5, description: 'Fifth', completed: false }
      ]
    }

    expect(pendingTodos(state).length).to.equal(2)
    expect(doneTodos(state).length).to.equal(3)
  })

  it('populateTodos populates data', () => {
    const state = { todos: [] }

    expect(state.todos.length).to.equal(0)

    populateTodos(state, [
      { id: 1, description: 'First', completed: true },
      { id: 2, description: 'Second', completed: true },
      { id: 3, description: 'Third', completed: true },
      { id: 4, description: 'Forth', completed: false },
      { id: 5, description: 'Fifth', completed: false }
    ])

    expect(state.todos.length).to.equal(5)
  })

  it('remoteError populates error', () => {
    const state = { error: null }

    expect(state.error).to.equal(null)

    remoteError(state, 'test error')

    expect(state.error).to.equal('test error')
  })
})
