import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import TodoTable from '@/components/TodoTable.vue'

describe('TodoTable.vue', () => {
  it('renders todos passed', () => {
    const todos = [
      { id: 1, description: 'First', completed: true },
      { id: 2, description: 'Second', completed: true },
      { id: 3, description: 'Third', completed: true }
    ]

    const wrapper = shallowMount(TodoTable, {
      propsData: { todos }
    })

    expect(wrapper.is(TodoTable)).to.equal(true)
    expect(wrapper.findAll('tr').length).to.equal(4)
    expect(wrapper.find('td').text()).to.equal('1')
  })
})
