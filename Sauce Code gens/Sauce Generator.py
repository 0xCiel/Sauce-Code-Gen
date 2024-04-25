import random
import pygame
import webbrowser

pygame.init()
bg_image = pygame.image.load('bg.png')
side_bg = pygame.image.load('sidebar.png')
pygame.display.set_caption('Sauce code Generator by Ciel')
pygame_icon = pygame.image.load('icon.png')
pygame.display.set_icon(pygame_icon)
screen = pygame.display.set_mode((1000, 800))
button_color = (255, 255, 255)
button_width = 200
button_height = 50
button_x_generate = 400 - button_width // 2
button_y_generate = 500 - button_height // 2
button_x_link = -button_width
button_y_link = button_y_generate

button_generate = pygame.Surface((button_width, button_height))
button_generate.fill(button_color)

button_link = pygame.Surface((button_width, button_height))
button_link.fill(button_color)

top_text_color = (0, 0, 255)
top_text = ""
top_font = pygame.font.Font(None, 48)
top_text_surface = top_font.render(top_text, True, top_text_color)
top_text_rect = top_text_surface.get_rect(center=(200, 50))

font = pygame.font.Font(None, 36)

text_generate = font.render("Generate code", True, (0, 0, 0))
text_generate_rect = text_generate.get_rect(center=(button_width // 2, button_height // 2))

text_generate_rect.x = button_x_generate + (button_width - text_generate.get_width()) // 2
text_generate_rect.y = button_y_generate + (button_height - text_generate.get_height()) // 2

text_link = font.render("Look up code", True, (0, 0, 0))
text_link_rect = text_link.get_rect(center=(button_x_link + button_width // 2, button_y_link + button_height // 2))

textbox_rect = pygame.Rect(600, 200, 300, 300)
textbox_color = (255, 255, 255)
text_color = (0, 0, 0)
text_font = pygame.font.Font(None, 36)
text = "yes"

running = True
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

        if event.type == pygame.MOUSEBUTTONDOWN:
            if event.button == 1:
                mouse_x, mouse_y = pygame.mouse.get_pos()
                if button_x_generate <= mouse_x <= button_x_generate + button_width and button_y_generate <= mouse_y <= button_y_generate + button_height:
                    random_number = random.randint(100000, 600000)
                    top_text = f"Generated Code: {random_number}"
                    top_text_surface = top_font.render(top_text, True, top_text_color)
                    top_text_rect.center = (200, 50)
                    button_x_link = 50
                    link_code = random_number

                if button_x_link <= mouse_x <= button_x_link + button_width and button_y_link <= mouse_y <= button_y_link + button_height:
                    webbrowser.open(f"https://nhentai.to/g/{link_code}")


    screen.fill((0, 0, 0))
    screen.blit(bg_image, (0, 0))
    screen.blit(side_bg, (400, 0))
    screen.blit(top_text_surface, top_text_rect)
    screen.blit(button_generate, (button_x_generate, button_y_generate))
    screen.blit(text_generate, text_generate_rect)
    screen.blit(button_link, (button_x_link, button_y_link))
    text_link_rect = text_link.get_rect(center=(button_x_link + button_width // 2, button_y_link + button_height // 2))
    screen.blit(text_link, text_link_rect)

    pygame.draw.rect(screen, textbox_color, textbox_rect)
    text_surface = text_font.render(text, True, text_color)
    screen.blit(text_surface, (textbox_rect.x + 10, textbox_rect.y + 10))

    pygame.display.flip()

pygame.quit()
