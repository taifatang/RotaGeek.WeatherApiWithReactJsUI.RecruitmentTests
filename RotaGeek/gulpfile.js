var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass"),
    rename = require("gulp-rename");

var paths = {
    webroot: "./wwwroot/"
}

paths.scss = paths.webroot + "css/**/*.scss";

gulp.task("sass", function () {
    return gulp.src(paths.scss)
        .pipe(sass({ outputStyle: 'compressed' }))
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task("sass-min", function () {
    return gulp.src(paths.scss)
        .pipe(sass({ outputStyle: 'compressed' }))
        .pipe(rename("site.min.css"))
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('watch-sass', function () {
    gulp.watch(paths.scss, ['sass']);
})