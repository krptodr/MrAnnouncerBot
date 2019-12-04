﻿class Fred {
	thumbsUp: Sprites;
	thumbsDown: Sprites;
	noIdea: Sprites;
	handsClasped: Sprites;
	one: Sprites;
	flipOff: Sprites;
	fistUp: Sprites;
	pointRight: Sprites;
	pointToViewer: Sprites;
	allAnimations: SpriteCollection;
	constructor() {

	}

	loadResources(): any {
		this.allAnimations = new SpriteCollection();
		this.thumbsUp = new Sprites('Fred/ThumbsUp/ThumbsUp', 98, fps30, AnimationStyle.Sequential, true);
		this.thumbsUp.name = 'ThumbsUp';
		this.thumbsUp.originX = 262;
		this.thumbsUp.originY = 218;

		this.thumbsDown = new Sprites('Fred/ThumbsDown/ThumbsDown', 103, fps30, AnimationStyle.Sequential, true);
		this.thumbsDown.name = 'ThumbsDown';
		this.thumbsDown.originX = 220;
		this.thumbsDown.originY = 217;

		this.noIdea = new Sprites('Fred/NoIdea/NoIdea', 101, fps30, AnimationStyle.Sequential, true);
		this.noIdea.name = 'NoIdea';
		this.noIdea.originX = 220;
		this.noIdea.originY = 247;

		this.handsClasped = new Sprites('Fred/HandsClasped/HandsClasped', 171, fps30, AnimationStyle.Sequential, true);
		this.handsClasped.name = 'HandsClasped';
		this.handsClasped.originX = 244;
		this.handsClasped.originY = 158;

		this.one = new Sprites('Fred/One/One', 44, fps30, AnimationStyle.Sequential, true);
		this.one.name = 'One';
		this.one.originX = 218;
		this.one.originY = 249;

		this.flipOff = new Sprites('Fred/FlipOff/FlipOff', 47, fps30, AnimationStyle.Sequential, true);
		this.flipOff.name = 'FlipOff';
		this.flipOff.originX = 180;
		this.flipOff.originY = 207;

		this.fistUp = new Sprites('Fred/FistUp/FistUp', 61, fps30, AnimationStyle.Sequential, true);
		this.fistUp.name = 'FistUp';
		this.fistUp.originX = 228;
		this.fistUp.originY = 148;

		this.pointRight = new Sprites('Fred/PointRight/PointRight', 92, fps30, AnimationStyle.Sequential, true);
		this.pointRight.name = 'PointRight';
		this.pointRight.originX = 211;
		this.pointRight.originY = 180;

		this.pointToViewer = new Sprites('Fred/PointToViewer/PointToViewer', 101, fps30, AnimationStyle.Sequential, true);
		this.pointToViewer.name = 'PointToViewer';
		this.pointToViewer.originX = 223;
		this.pointToViewer.originY = 248;

		this.allAnimations.add(this.thumbsUp);
		this.allAnimations.add(this.thumbsDown);
		this.allAnimations.add(this.noIdea);
		this.allAnimations.add(this.handsClasped);
		this.allAnimations.add(this.one);
		this.allAnimations.add(this.flipOff);
		this.allAnimations.add(this.fistUp);
		this.allAnimations.add(this.pointRight);
		this.allAnimations.add(this.pointToViewer);
	}

	draw(context: CanvasRenderingContext2D, now: number): any {
		this.allAnimations.draw(context, now);
	}

	playAnimation(animationName: string, playerX: number): void {
		let sprites: Sprites = this.allAnimations.getSpritesByName(animationName);
		if (!sprites)
			return;
		sprites.add(playerX, 1080);
	}
}
