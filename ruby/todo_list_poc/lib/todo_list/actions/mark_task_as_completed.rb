class TodoList::Actions::MarkTaskAsCompleted
  def initialize(tasks: raise)
    @tasks = tasks
  end

  def call task_id
    @tasks.find(task_id)
      .mark_as_completed
      .update_in(@tasks)
  end
end