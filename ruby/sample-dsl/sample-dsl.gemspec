# -*- encoding: utf-8 -*-
$:.push File.expand_path("../lib", __FILE__)
require "sample-dsl/version"

Gem::Specification.new do |s|
  s.name        = "sample-dsl"
  s.version     = Sample::Dsl::VERSION
  s.authors     = ["Omar Rodriguez"]
  s.email       = ["omarjavier15@gmail.com"]
  s.homepage    = ""
  s.summary     = %q{TODO: Write a gem summary}
  s.description = %q{TODO: Write a gem description}

  s.rubyforge_project = "sample-dsl"

  s.files         = `git ls-files`.split("\n")
  s.test_files    = `git ls-files -- {test,spec,features}/*`.split("\n")
  s.executables   = `git ls-files -- bin/*`.split("\n").map{ |f| File.basename(f) }
  s.require_paths = ["lib"]

  # specify any dependencies here; for example:
  s.add_development_dependency "rspec"
  s.add_development_dependency "simplecov"
  s.add_development_dependency "guard"
  s.add_development_dependency "guard-rspec"
  s.add_development_dependency "guard-bundler"
  s.add_development_dependency "rubygems-bundler"
  s.add_development_dependency "libnotify"
end
