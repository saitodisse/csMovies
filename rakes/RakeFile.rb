#--------------------------------------
# Dependencies
#--------------------------------------
require 'albacore'
#--------------------------------------

desc "execute package cmdto deploy"
task :default do
  package_path = "../OurMoviesMvc/obj/Release/Package/OurMoviesMvc.deploy.cmd"
  puts "package path: #{package_path}"
  sh "#{package_path} /y"
end

