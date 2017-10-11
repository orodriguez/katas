class TodoList::Actions::CreateTask
  def initialize(on_success: raise, on_invalid: raise, 
      task_factory: raise, tasks: raise)
    @on_success = on_success
    @on_invalid = on_invalid
    @task_factory = task_factory
    @tasks = tasks
  end

  def call title
    @task_factory.new(title: title)
      .validate(on_valid: method(:save),
                on_invalid: @on_invalid)
  end

  protected
  def save task
    @tasks.save(task).tap &@on_success
  end
end