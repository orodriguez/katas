require 'spec_helper'

describe "Create Task" do
  before do
    create_task title,
      on_success: -> (task) { @task = task },
      on_invalid: -> (errors) { @errors = errors }
  end

  context "happy case" do
    let(:title) { 'Take over the world' }
    
    subject { get_task @task.id }

    its(:title) { should eql 'Take over the world' }
  end

  context "without title" do
    let(:title) { '' }

    subject { @errors[:title] }

    it { should eql ["can't be blank"] }
  end
end