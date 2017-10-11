module SpecDSL
  def create_task(body, listeners)
    listeners.merge(task_factory: task_factory, tasks: tasks_repository)
      .tap do | colab |
        TodoList::Actions::CreateTask.new(colab).call body
      end
  end

  def get_task id
    TodoList::Actions::GetTask.new(tasks: tasks_repository).call id
  end

  def mark_as_completed task_id
    TodoList::Actions::MarkTaskAsCompleted.new(tasks: tasks_repository)
      .call task_id
  end

  def task_factory; TodoList::Entities::Task; end
end