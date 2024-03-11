from PIL import Image, ImageDraw, ImageFont
import json
import sys

def write_on_card(type):
    # Open and load the json file
    with open(f'Card/CardData/{type}Card.json', 'r') as json_player:
        card_data = json.load(json_player)

    # For each card in the json file, it will write text (It'll write: Abilities)
    for card in card_data:
        # # This is used for knowing the file name (NO NAME WILL BE WRITTEN ON THE CARD FROM HERE)
        card_name = card["Name"]
        # # A player card has 2 abilities while a soldier card has one
        # ability_one_type = card["AbilityA"]["type"]
        # ability_one_name = card["AbilityA"]["name"]
        # ability_one_description = card["AbilityA"]["Description"]

        # # Here we add one ability if the card is a player
        # if type == "Player":
        #     ability_two_type = card["AbilityB"]["type"]
        #     ability_two_name = card["AbilityB"]["name"]
        #     ability_two_description = card["AbilityB"]["Description"]

        #     card_text = f"{ability_one_name} ({ability_one_type}): {ability_one_description}\n{ability_two_name} ({ability_two_type}): {ability_two_description}"
        # else:
        #     card_text = f"{ability_one_name} ({ability_one_type}): {ability_one_description}"

        # # We want to make the text multiline so we'll cut for each line
        # if len(card_text) > 55:
        #     # A card can have one or multiple abilities, considering we're cutting at each new line, it should work both in both ways
        #     card_ability = card_text.split('\n')
        #     card_text = ""
        #     line = ""

        #     # We check each ability
        #     for ability in card_ability:
        #         # For not cutting inside a word, we're verifying if we can add it to the line without going above the limit first
        #         card_text_words = ability.split(' ')
        #         for word in card_text_words:
        #             if len(line + word) <= 55:
        #                 line += word + " "
        #             # Otherwise we end the line and start recording another
        #             else:
        #                 card_text += line + "\n"
        #                 line = word + " "
                
        #         # We add the rest of the line we were recording
        #         # A new line is added in case we are going to go through another ability
        #         card_text += line + "\n\n"
        #         line = ""

        # The template used (card without abilities written on)
        img = Image.open(f'Resources/Images/Cards/{type}/{card_name}.png')

        # Let it draw.
        ImageDraw.Draw(img).text((17, 337), "COMING SOON", fill='rgb(255, 255, 255)', stroke_fill='rgb(0,0,0)', stroke_width=2, font=ImageFont.truetype('calibri.ttf', 20), italic=True)

        # Save the image
        img.save(f'Resources/Images/.Cards/{type}/{card_name}.png')

def main():
    write_on_card("Player")
    write_on_card("Soldier")
    return 0

if __name__ == "__main__":
    sys.exit(main())
