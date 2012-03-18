/* Copyright (c) 2009 Kelvin Luck (kelvin AT kelvinluck DOT com || http://www.kelvinluck.com)
 * Dual licensed under the MIT (http://www.opensource.org/licenses/mit-license.php) 
 * and GPL (http://www.opensource.org/licenses/gpl-license.php) licenses.
 * 
 * See http://kelvinluck.com/assets/jquery/jScrollPaneH/
 * $Id: jScrollPaneH.js 93 2010-06-01 08:17:28Z kelvin.luck $
 */

/**
 * Replace the vertical scroll bars on any matched elements with a fancy
 * styleable (via CSS) version. With JS disabled the elements will
 * gracefully degrade to the browsers own implementation of overflow:auto.
 * If the mousewheel plugin has been included on the page then the scrollable areas will also
 * respond to the mouse wheel.
 *
 * @example jQuery(".scroll-pane").jScrollPaneH();
 *
 * @name jScrollPaneH
 * @type jQuery
 * @param Object	settings	hash with options, described below.
 *								scrollbarHeight	-	The width of the generated scrollbar in pixels
 *								scrollbarMargin	-	The amount of space to leave on the side of the scrollbar in pixels
 *								wheelSpeed		-	The speed the pane will scroll in response to the mouse wheel in pixels
 *								showArrows		-	Whether to display arrows for the user to scroll with
 *								arrowSize		-	The height of the arrow buttons if showArrows=true
 *								animateTo		-	Whether to animate when calling scrollTo and scrollBy
 *								dragMinWidth	-	The minimum height to allow the drag bar to be
 *								dragMaxWidth	-	The maximum height to allow the drag bar to be
 *								animateInterval	-	The interval in milliseconds to update an animating scrollPane (default 100)
 *								animateStep		-	The amount to divide the remaining scroll distance by when animating (default 3)
 *								maintainPosition-	Whether you want the contents of the scroll pane to maintain it's position when you re-initialise it - so it doesn't scroll as you add more content (default true)
 *								tabIndex		-	The tabindex for this jScrollPaneH to control when it is tabbed to when navigating via keyboard (default 0)
 *								enableKeyboardNavigation - Whether to allow keyboard scrolling of this jScrollPaneH when it is focused (default true)
 *								animateToInternalLinks - Whether the move to an internal link (e.g. when it's focused by tabbing or by a hash change in the URL) should be animated or instant (default false)
 *								scrollbarOnTop	-	Display the scrollbar on the left side?  (needs stylesheet changes, see examples.html)
 *								reinitialiseOnImageLoad - Whether the jScrollPaneH should automatically re-initialise itself when any contained images are loaded (default false)
 *								leftCapWidth	-	The height of the "cap" area between the left of the jScrollPaneH and the left of the track/ buttons
 *								rightCapWidth	-	The height of the "cap" area between the right of the jScrollPaneH and the right of the track/ buttons
 *								observeHash		-	Whether jScrollPaneH should attempt to automagically scroll to the correct place when an anchor inside the scrollpane is linked to (default true)
 * @return jQuery
 * @cat Plugins/jScrollPaneH
 * @author Kelvin Luck (kelvin AT kelvinluck DOT com || http://www.kelvinluck.com)
 */

(function ($) {

    $.jScrollPaneH = {
        active: []
    };
    $.fn.jScrollPaneH = function (settings) {
        settings = $.extend({}, $.fn.jScrollPaneH.defaults, settings);

        var rf = function () { return false; };

        return this.each(
		function () {
		    var $this = $(this);
		    var paneEle = this;
		    var currentScrollPosition = 0;
		    var paneWidth;
		    var paneHeight;
		    var trackHeight;
		    var trackOffset = settings.leftCapWidth;
		    var $container;

		    if ($(this).parent().is('.jScrollPaneHContainer')) {
		        $container = $(this).parent();
		        currentScrollPosition = settings.maintainPosition ? $this.position().left : 0;
		        var $c = $(this).parent();
		        paneHeight = $c.innerHeight();
		        paneWidth = $c.outerWidth();
		        $('>.jScrollPaneHTrack, >.jScrollArrowUp, >.jScrollArrowDown, >.jScrollCap', $c).remove();
		        $this.css({ 'left': 0 });
		    } else {
		        $this.data('originalStyleTag', $this.attr('style'));
		        // Switch the element's overflow to hidden to ensure we get the size of the element without the scrollbars [http://plugins.jquery.com/node/1208]
		        $this.css('overflow', 'hidden');
		        this.originalPadding = $this.css('paddingTop') + ' ' + $this.css('paddingRight') + ' ' + $this.css('paddingBottom') + ' ' + $this.css('paddingLeft');
		        this.originalSidePaddingTotal = (parseInt($this.css('paddingTop')) || 0) + (parseInt($this.css('paddingBottom')) || 0);
		        paneHeight = $this.innerHeight();
		        paneWidth = $this.innerWidth();
		        $container = $('<div></div>')
					.attr({ 'className': 'jScrollPaneHContainer' })
					.css(
						{
						    'height': paneHeight + 'px',
						    'width': paneWidth + 'px'
						}
					);
		        if (settings.enableKeyboardNavigation) {
		            $container.attr(
						'tabindex',
						settings.tabIndex
					);
		        }
		        $this.wrap($container);
		        $container = $this.parent();
		        // deal with text size changes (if the jquery.em plugin is included)
		        // and re-initialise the scrollPane so the track maintains the
		        // correct size
		        $(document).bind(
					'emchange',
					function (e, cur, prev) {
					    $this.jScrollPaneH(settings);
					}
				);

		    }
		    trackWidth = paneWidth;

		    if (settings.reinitialiseOnImageLoad) {
		        // code inspired by jquery.onImagesLoad: http://plugins.jquery.com/project/onImagesLoad
		        // except we re-initialise the scroll pane when each image loads so that the scroll pane is always up to size...
		        // TODO: Do I even need to store it in $.data? Is a local variable here the same since I don't pass the reinitialiseOnImageLoad when I re-initialise?
		        var $imagesToLoad = $.data(paneEle, 'jScrollPaneHImagesToLoad') || $('img', $this);
		        var loadedImages = [];

		        if ($imagesToLoad.length) {
		            $imagesToLoad.each(function (i, val) {
		                $(this).bind('load readystatechange', function () {
		                    if ($.inArray(i, loadedImages) == -1) { //don't double count images
		                        loadedImages.push(val); //keep a record of images we've seen
		                        $imagesToLoad = $.grep($imagesToLoad, function (n, i) {
		                            return n != val;
		                        });
		                        $.data(paneEle, 'jScrollPaneHImagesToLoad', $imagesToLoad);
		                        var s2 = $.extend(settings, { reinitialiseOnImageLoad: false });
		                        $this.jScrollPaneH(s2); // re-initialise
		                    }
		                }).each(function (i, val) {
		                    if (this.complete || this.complete === undefined) {
		                        //needed for potential cached images
		                        this.src = this.src;
		                    }
		                });
		            });
		        };
		    }

		    var p = this.originalSidePaddingTotal;
		    var realPaneHeight = paneHeight - settings.scrollbarHeight - settings.scrollbarMargin - p;

		    var cssToApply = {
		        'width': 'auto',
		        'height': realPaneHeight + 'px'
		    }

		    if (settings.scrollbarOnTop) {
		        cssToApply.paddingTop = settings.scrollbarMargin + settings.scrollbarHeight + 'px';
		    } else {
		        cssToApply.paddingBottom = settings.scrollbarMargin + 'px';
		    }

		    $this.css(cssToApply);

		    var contentWidth = $("div", $this).outerWidth();
		    var percentInView = paneWidth / contentWidth;

		    var isScrollable = percentInView < .99;
		    $container[isScrollable ? 'addClass' : 'removeClass']('jScrollPaneHScrollable');

		    if (isScrollable) {
		        $container.append(
					$('<div></div>').addClass('jScrollCap jScrollCapLeft').css({ width: settings.leftCapWidth }),
					$('<div></div>').attr({ 'className': 'jScrollPaneHTrack' }).css({ 'height': settings.scrollbarHeight + 'px' }).append(
						$('<div></div>').attr({ 'className': 'jScrollPaneHDrag' }).css({ 'height': settings.scrollbarHeight + 'px' }).append(
							$('<div></div>').attr({ 'className': 'jScrollPaneHDragTop' }).css({ 'height': settings.scrollbarHeight + 'px' }),
							$('<div></div>').attr({ 'className': 'jScrollPaneHDragBottom' }).css({ 'height': settings.scrollbarHeight + 'px' })
						)
					),
					$('<div></div>').addClass('jScrollCap jScrollCapRight').css({ width: settings.rightCapWidth })
				);

		        var $track = $('>.jScrollPaneHTrack', $container);
		        var $drag = $('>.jScrollPaneHTrack .jScrollPaneHDrag', $container);


		        var currentArrowDirection;
		        var currentArrowTimerArr = []; // Array is used to store timers since they can stack up when dealing with keyboard events. This ensures all timers are cleaned up in the end, preventing an acceleration bug.
		        var currentArrowInc;
		        var whileArrowButtonDown = function () {
		            if (currentArrowInc > 4 || currentArrowInc % 4 == 0) {
		                positionDrag(dragPosition + currentArrowDirection * mouseWheelMultiplier);
		            }
		            currentArrowInc++;
		        };

		        if (settings.enableKeyboardNavigation) {
		            $container.bind(
						'keydown.jscrollpane',
						function (e) {
						    switch (e.keyCode) {
						        case 37: //left
						            currentArrowDirection = -1;
						            currentArrowInc = 0;
						            whileArrowButtonDown();
						            currentArrowTimerArr[currentArrowTimerArr.length] = setInterval(whileArrowButtonDown, 100);
						            return false;
						        case 39: //right
						            currentArrowDirection = 1;
						            currentArrowInc = 0;
						            whileArrowButtonDown();
						            currentArrowTimerArr[currentArrowTimerArr.length] = setInterval(whileArrowButtonDown, 100);
						            return false;
						        case 33: // page left
						        case 34: // page right
						            // TODO
						            return false;
						        default:
						    }
						}
					).bind(
						'keyup.jscrollpane',
						function (e) {
						    if (e.keyCode == 37 || e.keyCode == 39) {
						        for (var i = 0; i < currentArrowTimerArr.length; i++) {
						            clearInterval(currentArrowTimerArr[i]);
						        }
						        return false;
						    }
						}
					);
		        }

		        if (settings.showArrows) {

		            var currentArrowButton;
		            var currentArrowInterval;

		            var onArrowMouseUp = function (event) {
		                $('html').unbind('mouseup', onArrowMouseUp);
		                currentArrowButton.removeClass('jScrollActiveArrowButton');
		                clearInterval(currentArrowInterval);
		            };
		            var onArrowMouseDown = function () {
		                $('html').bind('mouseup', onArrowMouseUp);
		                currentArrowButton.addClass('jScrollActiveArrowButton');
		                currentArrowInc = 0;
		                whileArrowButtonDown();
		                currentArrowInterval = setInterval(whileArrowButtonDown, 100);
		            };
		            $container
						.append(
							$('<a></a>')
								.attr(
									{
									    'href': 'javascript:;',
									    'className': 'jScrollArrowUp',
									    'tabindex': -1
									}
								)
								.css(
									{
									    'height': settings.scrollbarHeight + 'px',
									    'left': settings.leftCapWidth + 'px'
									}
								)
								.html('Scroll left')
								.bind('mousedown', function () {
								    currentArrowButton = $(this);
								    currentArrowDirection = -1;
								    onArrowMouseDown();
								    this.blur();
								    return false;
								})
								.bind('click', rf),
							$('<a></a>')
								.attr(
									{
									    'href': 'javascript:;',
									    'className': 'jScrollArrowRight',
									    'tabindex': -1
									}
								)
								.css(
									{
									    'height': settings.scrollbarHeight + 'px',
									    'right': settings.rightCapWidth + 'px'
									}
								)
								.html('Scroll right')
								.bind('mousedown', function () {
								    currentArrowButton = $(this);
								    currentArrowDirection = 1;
								    onArrowMouseDown();
								    this.blur();
								    return false;
								})
								.bind('click', rf)
						);
		            var $leftArrow = $('>.jScrollArrowLeft', $container);
		            var $rightArrow = $('>.jScrollArrowRight', $container);
		        }

		        if (settings.arrowSize) {
		            trackWidth = paneWidth - settings.arrowSize - settings.arrowSize;
		            trackOffset += settings.arrowSize;
		        } else if ($leftArrow) {
		            var leftArrowWidth = $leftArrow.width();
		            settings.arrowSize = leftArrowWidth;
		            trackWidth = paneWidth - leftArrowWidth - $rightArrow.width();
		            trackOffset += leftArrowWidth;
		        }
		        trackWidth -= settings.leftCapWidth + settings.rightCapWidth;
		        $track.css({ 'width': trackWidth + 'px', left: trackOffset + 'px' })

		        var $pane = $(this).css({ 'position': 'absolute', 'overflow': 'visible' });

		        var currentOffset;
		        var maxX;
		        var mouseWheelMultiplier;
		        // store this in a seperate variable so we can keep track more accurately than just updating the css property..
		        var dragPosition = 0;
		        var dragMiddle = percentInView * paneWidth / 2;

		        // pos function borrowed from tooltip plugin and adapted...
		        var getPos = function (event, c) {
		            var p = c == 'X' ? 'Left' : 'Top';
		            return event['page' + c] || (event['client' + c] + (document.documentElement['scroll' + p] || document.body['scroll' + p])) || 0;
		        };

		        var ignoreNativeDrag = function () { return false; };

		        var initDrag = function () {
		            ceaseAnimation();
		            currentOffset = $drag.offset(false);
		            currentOffset.left -= dragPosition;
		            maxX = trackWidth - $drag[0].offsetWidth;
		            mouseWheelMultiplier = 2 * settings.wheelSpeed * maxX / contentWidth;
		        };

		        var onStartDrag = function (event) {
		            initDrag();
		            dragMiddle = getPos(event, 'X') - dragPosition - currentOffset.left;
		            $('html').bind('mouseup', onStopDrag).bind('mousemove', updateScroll).bind('mouseleave', onStopDrag)
		            if ($.browser.msie) {
		                $('html').bind('dragstart', ignoreNativeDrag).bind('selectstart', ignoreNativeDrag);
		            }
		            return false;
		        };
		        var onStopDrag = function () {
		            $('html').unbind('mouseup', onStopDrag).unbind('mousemove', updateScroll);
		            dragMiddle = percentInView * paneWidth / 2;
		            if ($.browser.msie) {
		                $('html').unbind('dragstart', ignoreNativeDrag).unbind('selectstart', ignoreNativeDrag);
		            }
		        };
		        var positionDrag = function (destX) {
		            $container.scrollLeft(0);
		            destX = destX < 0 ? 0 : (destX > maxX ? maxX : destX);
		            dragPosition = destX;
		            $drag.css({ 'left': destX + 'px' });
		            var p = destX / maxX;
		            $this.data('jScrollPaneHPosition', (paneWidth - contentWidth) * -p);
		            $pane.css({ 'left': ((paneWidth - contentWidth) * p) + 'px' });
		            $this.trigger('scroll');
		            if (settings.showArrows) {
		                $leftArrow[destX == 0 ? 'addClass' : 'removeClass']('disabled');
		                $rightArrow[destX == maxX ? 'addClass' : 'removeClass']('disabled');
		            }
		        };
		        var updateScroll = function (e) {
		            positionDrag(getPos(e, 'X') - currentOffset.left - dragMiddle);
		        };

		        var dragW = Math.max(Math.min(percentInView * (paneWidth - settings.arrowSize * 2), settings.dragMaxWidth), settings.dragMinWidth);

		        $drag.css(
					{ 'width': dragW + 'px' }
				).bind('mousedown', onStartDrag);

		        var trackScrollInterval;
		        var trackScrollInc;
		        var trackScrollMousePos;
		        var doTrackScroll = function () {
		            if (trackScrollInc > 8 || trackScrollInc % 4 == 0) {
		                positionDrag((dragPosition - ((dragPosition - trackScrollMousePos) / 2)));
		            }
		            trackScrollInc++;
		        };
		        var onStopTrackClick = function () {
		            clearInterval(trackScrollInterval);
		            $('html').unbind('mouseup', onStopTrackClick).unbind('mousemove', onTrackMouseMove);
		        };
		        var onTrackMouseMove = function (event) {
		            trackScrollMousePos = getPos(event, 'X') - currentOffset.left - dragMiddle;
		        };
		        var onTrackClick = function (event) {
		            initDrag();
		            onTrackMouseMove(event);
		            trackScrollInc = 0;
		            $('html').bind('mouseup', onStopTrackClick).bind('mousemove', onTrackMouseMove);
		            trackScrollInterval = setInterval(doTrackScroll, 100);
		            doTrackScroll();
		            return false;
		        };

		        $track.bind('mousedown', onTrackClick);

		        $container.bind(
					'mousewheel',
					function (event, delta) {
					    delta = delta || (event.wheelDelta ? event.wheelDelta / 120 : (event.detail) ?
-event.detail / 3 : 0);
					    initDrag();
					    ceaseAnimation();
					    var d = dragPosition;
					    positionDrag(dragPosition - delta * mouseWheelMultiplier);
					    var dragOccured = d != dragPosition;
					    return !dragOccured;
					}
				);

		        var _animateToPosition;
		        var _animateToInterval;
		        function animateToPosition() {
		            var diff = (_animateToPosition - dragPosition) / settings.animateStep;
		            if (diff > 1 || diff < -1) {
		                positionDrag(dragPosition + diff);
		            } else {
		                positionDrag(_animateToPosition);
		                ceaseAnimation();
		            }
		        }
		        var ceaseAnimation = function () {
		            if (_animateToInterval) {
		                clearInterval(_animateToInterval);
		                delete _animateToPosition;
		            }
		        };
		        var scrollTo = function (pos, preventAni) {
		            if (typeof pos == "string") {
		                // Legal hash values aren't necessarily legal jQuery selectors so we need to catch any
		                // errors from the lookup...
		                try {
		                    $e = $(pos, $this);
		                } catch (err) {
		                    return;
		                }
		                if (!$e.length) return;
		                pos = $e.offset().left - $this.offset().left;
		            }
		            ceaseAnimation();
		            var maxScroll = contentWidth - paneWidth;
		            pos = pos > maxScroll ? maxScroll : pos;
		            $this.data('jScrollPaneHMaxScroll', maxScroll);
		            var destDragPosition = pos / maxScroll * maxX;
		            if (preventAni || !settings.animateTo) {
		                positionDrag(destDragPosition);
		            } else {
		                $container.scrollLeft(0);
		                _animateToPosition = destDragPosition;
		                _animateToInterval = setInterval(animateToPosition, settings.animateInterval);
		            }
		        };
		        $this[0].scrollTo = scrollTo;

		        $this[0].scrollBy = function (delta) {
		            var currentPos = -parseInt($pane.css('left')) || 0;
		            scrollTo(currentPos + delta);
		        };

		        initDrag();

		        scrollTo(-currentScrollPosition, true);

		        // Deal with it when the user tabs to a link or form element within this scrollpane
		        $('*', this).bind(
					'focus',
					function (event) {
					    var $e = $(this);

					    // loop through parents adding the offset left of any elements that are relatively positioned between
					    // the focused element and the jScrollPaneHContainer so we can get the true distance from the left
					    // of the focused element to the left of the scrollpane...
					    var eleLeft = 0;

					    var preventInfiniteLoop = 100;

					    while ($e[0] != $this[0]) {
					        eleLeft += $e.position().left;
					        $e = $e.offsetParent();
					        if (!preventInfiniteLoop--) {
					            return;
					        }
					    }

					    var viewportLeft = -parseInt($pane.css('left')) || 0;
					    var maxVisibleEleLeft = viewportLeft + paneWidth;
					    var eleInView = eleLeft > viewportLeft && eleLeft < maxVisibleEleLeft;
					    if (!eleInView) {
					        var destPos = eleLeft - settings.scrollbarMargin;
					        if (eleLeft > viewportLeft) { // element is below viewport - scroll so it is at right.
					            destPos += $(this).width() + 15 + settings.scrollbarMargin - paneWidth;
					        }
					        scrollTo(destPos);
					    }
					}
				)

		        if (settings.observeHash) {
		            if (location.hash && location.hash.length > 1) {
		                setTimeout(function () {
		                    scrollTo(location.hash);
		                }, $.browser.safari ? 100 : 0);
		            }

		            // use event delegation to listen for all clicks on links and hijack them if they are links to
		            // anchors within our content...
		            $(document).bind('click', function (e) {
		                $target = $(e.target);
		                if ($target.is('a')) {
		                    var h = $target.attr('href');
		                    if (h && h.substr(0, 1) == '#' && h.length > 1) {
		                        setTimeout(function () {
		                            scrollTo(h, !settings.animateToInternalLinks);
		                        }, $.browser.safari ? 100 : 0);
		                    }
		                }
		            });
		        }

		        // Deal with dragging and selecting text to make the scrollpane scroll...
		        function onSelectScrollMouseDown(e) {
		            $(document).bind('mousemove.jScrollPaneHDragging', onTextSelectionScrollMouseMove);
		            $(document).bind('mouseup.jScrollPaneHDragging', onSelectScrollMouseUp);

		        }

		        var textDragDistanceAway;
		        var textSelectionInterval;

		        function onTextSelectionInterval() {
		            direction = textDragDistanceAway < 0 ? -1 : 1;
		            $this[0].scrollBy(textDragDistanceAway / 2);
		        }

		        function clearTextSelectionInterval() {
		            if (textSelectionInterval) {
		                clearInterval(textSelectionInterval);
		                textSelectionInterval = undefined;
		            }
		        }

		        function onTextSelectionScrollMouseMove(e) {
		            var offset = $this.parent().offset().left;
		            var maxOffset = offset + paneWidth;
		            var mouseOffset = getPos(e, 'X');
		            textDragDistanceAway = mouseOffset < offset ? mouseOffset - offset : (mouseOffset > maxOffset ? mouseOffset - maxOffset : 0);
		            if (textDragDistanceAway == 0) {
		                clearTextSelectionInterval();
		            } else {
		                if (!textSelectionInterval) {
		                    textSelectionInterval = setInterval(onTextSelectionInterval, 100);
		                }
		            }
		        }

		        function onSelectScrollMouseUp(e) {
		            $(document)
					  .unbind('mousemove.jScrollPaneHDragging')
					  .unbind('mouseup.jScrollPaneHDragging');
		            clearTextSelectionInterval();
		        }

		        $container.bind('mousedown.jScrollPaneH', onSelectScrollMouseDown);


		        $.jScrollPaneH.active.push($this[0]);

		        
		            scrollTo(99999999999, false);

		        


		    } else {
		        $this.css(
					{
					    'width': paneWidth + 'px',
					    'height': paneHeight - this.originalSidePaddingTotal + 'px',
					    'padding': this.originalPadding
					}
				);
		        $this[0].scrollTo = $this[0].scrollBy = function () { };
		        // clean up listeners
		        $this.parent().unbind('mousewheel').unbind('mousedown.jScrollPaneH').unbind('keydown.jscrollpane').unbind('keyup.jscrollpane');
		    }

		}
	)
    };

    $.fn.jScrollPaneHRemove = function () {
        $(this).each(function () {
            $this = $(this);
            var $c = $this.parent();
            if ($c.is('.jScrollPaneHContainer')) {
                $this.css(
				{
				    'left': '',
				    'width': '',
				    'height': '',
				    'padding': '',
				    'overflow': '',
				    'position': ''
				}
			);
                $this.attr('style', $this.data('originalStyleTag'));
                $c.after($this).remove();
            }
        });
    }

    $.fn.jScrollPaneH.defaults = {
        scrollbarHeight: 8,
        scrollbarMargin: 0,
        wheelSpeed: 18,
        showArrows: false,
        arrowSize: 0,
        animateTo: true,
        dragMinWidth: 1,
        dragMaxWidth: 99999,
        animateInterval: 100,
        animateStep: 3,
        maintainPosition: true,
        scrollbarOnTop: false,
        reinitialiseOnImageLoad: false,
        tabIndex: 0,
        enableKeyboardNavigation: true,
        animateToInternalLinks: false,
        leftCapWidth: 0,
        rightCapWidth: 0,
        observeHash: true,
        scrollAutomatico: true
    };

    // clean up the scrollTo expandos
    $(window)
	.bind('unload', function () {
	    var els = $.jScrollPaneH.active;
	    for (var i = 0; i < els.length; i++) {
	        els[i].scrollTo = els[i].scrollBy = null;
	    }
	}
);

})(jQuery);