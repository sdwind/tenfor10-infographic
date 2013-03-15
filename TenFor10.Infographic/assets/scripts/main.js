$(document).ready(function() {

});

var site = (function () {

	return {
		render: function(template, context, done) {
			dust.render(template, context, function(err, out) {
				if (err !== null) {
					site.showFailure({ op: "rendering template", responseText: err });
					return;
				}

				done(out);
			});
		}
	};
} ());