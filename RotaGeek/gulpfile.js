var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass");

var paths = {
    webroot: "./wwwroot/"
}

paths.scss = paths.webroot + "css/**/*.scss";

gulp.task("sass", function () {
    return gulp.src(paths.scss)
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('watch-sass', function () {
    gulp.watch(paths.scss, ['sass']);
})