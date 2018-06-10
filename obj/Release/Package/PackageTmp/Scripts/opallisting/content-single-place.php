<?php
/**
 * $Desc$
 *
 * @version    $Id$
 * @package    $package$
 * @author     Opal Team <info@wpopal.com >
 * @copyright  Copyright (C) 2014 wpopal.com. All Rights Reserved.
 * @license    GNU/GPL v2 or later http://www.gnu.org/licenses/gpl-2.0.html
 *
 * @website  http://www.wpopal.com
 * @support  http://www.wpopal.com/support/forum.html
 */

defined( 'ABSPATH' ) || exit();

$place = opallisting_get_place( get_the_ID() );

/**
 * Remove specification tab content
 */
add_filter( 'opallisting_single_place_tabs', 'opallisting_remove_specification_tab' );

?>

<article id="post-<?php the_ID(); ?>" itemscope itemtype="http://schema.org/Place" <?php post_class( 'version-1' ); ?>>

	<?php do_action( 'opallisting_single_place_before' );  ?>

	<nav class="opallisting-tab-v1">
		<?php opallisting_get_template( 'single-place/tabs' ); ?>
	</nav>

	<?php opallisting_get_template( 'single-place/tab-contents' ); ?>

	<?php do_action( 'opallisting_after_single_place_summary' ); ?>

	<div class="clear clearfix"></div>

</article><!-- #post-## -->

<?php

/**
 * Remove specification tab content
 */
remove_filter( 'opallisting_single_place_tabs', 'opallisting_remove_specification_tab' );