class TodoList::Entities::Task
  include ActiveModel::Validations

  validates :title, presence: true

  def initialize(id: nil, title: nil, completed: false)
    @id = id
    @title = title
    @completed = completed
  end

  attr_reader :id, :title, :completed

  def mark_as_completed
    update completed: !completed
  end

  def validate(on_valid: raise, on_invalid: raise)
    return on_invalid.call(errors) unless valid?
    on_valid.call self
  end

  def update(attributes)
    self.class.new to_h.merge(attributes)
  end

  def update_in(respository)
    respository.update self
  end

  def to_h
    { id: id, title: title, completed: completed }
  end
end