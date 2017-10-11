require 'spec_helper'

describe "Mark Task as completed" do
  before do
    create_task 'Take over the world',
      on_success: -> (task) { @task = task },
      on_invalid: -> (errors) do 
        raise "Could not save task #{errors}"
      end
  end

  context "happy case" do
    before { mark_as_completed @task.id }
    
    subject { get_task @task.id }

    its(:completed) { should be_true }
  end
end