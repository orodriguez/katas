require 'ostruct'

class FakeRepo
  include Enumerable

  def initialize
    @next_id = 0
    @objects = []
  end

  def each; @objects.each { |o| yield o }; end

  def save(obj)
    new_obj = obj.update(id: @next_id += 1)
    self << new_obj
    new_obj
  end

  def update(obj)
    @objects.delete_if { |o| o.id == obj.id }
    self << obj
  end

  def find id
    super { |obj| obj.id == id }
  end

  protected
    def <<(obj)
      @objects << obj
    end
end

module UnitSpecDSL
  include SpecDSL

  def tasks_repository; @tasks ||= FakeRepo.new end
end