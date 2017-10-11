class TodoList::Actions::GetTask
  def initialize(tasks: raise)
    @tasks = tasks
  end

  def call id
    @tasks.find id
  end
end