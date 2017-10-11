class Task < ActiveRecord::Base
  def self.save obj
    ar_obj = new(obj.to_h)
    ar_obj.save
    obj.update id: ar_obj.id
  end

  def to_h
    { id: id, title: title, completed: completed }
  end

  class << self
    alias :old_find :find

    def find *args
      TodoList::Entities::Task.new super(*args).to_h
    end
    
    def update obj
      old_find(obj.id).update_attributes(obj.to_h)
    end
  end
end