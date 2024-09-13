/**
 *	@package vt_grid_mag
 *	@since 1.0
 */
(function($) {
	"use strict";

	var vt_grid_mag = {

		cache: {},

		init: function() {
			this.cacheElements();
			this.bindEvents();
		},

		cacheElements: function() {
			this.cache.$window     = $(window);
			this.cache.$document   = $(document);
			this.cache.$body       = $('body');
			this.cache.$menuWrap   = $('#navigation');
			this.cache.$menuToggle = $('.menu-toggle');
			this.cache.$adminbar   = $('#wpadminbar');
			this.cache.dontClose   = false;
		},

		bindEvents: function() {
			var self = this;

			// Masonry.
			self.cache.$document.on('ready', function() {
				self.masonryInit();
			});
			
			// FitVids.
			self.cache.$document.on('ready post-load', function() {
				self.fitVidsInit();
			});

			// Mobile Menu.
			self.cache.$menuToggle.on('click', function(e) {
				e.preventDefault();
				e.stopPropagation();
				self.mobileMenu();
			});
			self.cache.$document.on('click', 'body.pushed', function() {
				if ( false === self.cache.dontClose ) {
					self.mobileMenu();
				}
				self.cache.dontClose = false;
			});
			self.cache.$menuWrap.on('click', function(e) {
				self.cache.dontClose = true;
			});
		},

		// Initialize the FitVids script.
		fitVidsInit: function() {
			if ( ! $.fn.fitVids ) {
				return;
			};
			this.cache.$fitvids = $('.site-main');
			this.cache.$fitvids.fitVids();
		},

		// Initialize the Masonry layout.
		masonryInit: function() {
			if ( ! $.fn.masonry || 'undefined' === typeof imagesLoaded ) {
				return;
			};
			this.cache.$postWrap = $('.post-container');
			if ( this.cache.$postWrap.length < 1 ) {
				return;
			};

			// Fire Masonry after images are loaded.
			this.cache.$postWrap.imagesLoaded(function() {
				vt_grid_mag.cache.$postWrap.masonry({
					itemSelector : 'article'
				});
			});

			// Infinite Scroll support.
			if (this.cache.$body.hasClass('infinite-scroll')) {
				this.cache.$document.on('post-load', function() {
					var $appended = $('.infinite-wrap article');
					vt_grid_mag.cache.$postWrap.imagesLoaded(function() {
						vt_grid_mag.cache.$postWrap.masonry( 'appended', $appended ).masonry({transitionDuration: 0});
						$appended.unwrap();
					});
				});
			};
		},

		mobileMenu: function() {
			var $body     = this.cache.$body,
				$menuWrap = this.cache.$menuWrap,
				$adminbar = this.cache.$adminbar;
			if( ! $body.hasClass('pushed') ) {
				$adminbar.removeClass('moved');
				$menuWrap.hide();
			};

			if ( $menuWrap.hasClass('on-canvas') ) {
				$body.removeClass('pushed');
				$menuWrap.removeClass('on-canvas');
			} else {
				$body.addClass('pushed');
				$menuWrap.addClass('on-canvas').show();
				$adminbar.addClass('moved');
			};
		}
	};

	vt_grid_mag.init();
	
})(jQuery);